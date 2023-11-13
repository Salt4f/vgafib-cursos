using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Org.BouncyCastle.Utilities;
using VGAFIBCursos.Data;
using VGAFIBCursos.Models;

namespace VGAFIBCursos.Controllers
{
    public class CursosController : Controller
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public CursosController(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cursos!.ToListAsync());
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind(nameof(Estudiante.CursoId),nameof(Estudiante.Nombre),nameof(Estudiante.Apellidos),nameof(Estudiante.Dni),nameof(Estudiante.NombreCompanero),nameof(Estudiante.Email),nameof(Estudiante.Fiber),nameof(Estudiante.PaymentMethod))]Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiante.FechaInscripcion = DateTime.UtcNow;
                await _context.AddAsync(estudiante);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return View(false);
                }

                var curso = await _context.Cursos!.FirstOrDefaultAsync<Curso?>(c => c!.Id == estudiante.CursoId);

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    var server = _config.GetValue<string>("Mail:Server");
                    var port = _config.GetValue<int>("Mail:Port");
                    var ssl = _config.GetValue<bool>("Mail:SSL");
                    var user = _config.GetValue<string>("Mail:User");
                    var password = _config.GetValue<string>("Mail:Password");

                    var iban = _config.GetValue<string>("Mail:Iban");
                    var paypal = _config.GetValue<string>("Mail:PayPal");

                    var precioBajo = _config.GetValue<string>("Mail:PrecioBajo");
                    var precioAlto = _config.GetValue<string>("Mail:PrecioAlto");

                    await client.ConnectAsync(server, port, ssl);
                    await client.AuthenticateAsync(user, password);

                    var mail = new MimeMessage();
                    mail.From.Add(new MailboxAddress("VGAFIB", user));
                    mail.To.Add(new MailboxAddress(estudiante.Nombre + " " + estudiante.Apellidos, estudiante.Email));
                    mail.Subject = $"Inscripción {curso!.Name}";

                    if (await _context.Estudiantes!.CountAsync<Estudiante>(e => e.CursoId == curso.Id) > curso.Plazas)
                    {
                        mail.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                        {
                            Text = $"¡Hola!\n\nHemos recibido tu solicitud de inscripción al curso. Ahora mismo las plazas del curso están todas completas, en caso de que haya alguna plaza disponible te avisaremos.\n\nUn saludo,\nProfesorado de cursos VGAFIB"
                        };
                    }
                    else
                    {
                        mail.Body = new TextPart(MimeKit.Text.TextFormat.Plain) {
                            Text = $"¡Hola!\n\nHemos recibido tu solicitud de inscripción al curso. Tienes tu plaza reservada durante una semana, durante la cual puedes realizar el pago de la matrícula.\n\nEl precio a pagar por la matrícula es de {(estudiante.NombreCompanero != null ? precioBajo:precioAlto)}€, y puedes hacer el pago a:\n\n{(estudiante.PaymentMethod == PaymentMethod.Transfer ? iban : paypal)}\n\nRecuerda indicar claramente tu nombre y/ o DNI al realizar el pago. Es especialmente importante que conste el nombre o DNI que se ha indicado a la hora de hacer la inscripción para poder saber qué matrícula se está pagando. Recomendamos que envíes un email con un recibo para confirmar el pago de forma segura y rápida.\n\nCualquier duda que tengas, respóndenos a este mismo correo y te atenderemos lo antes posible.\n\nRecuerda que tienes una semana para hacer efectivo el pago. En caso contrario, la reserva de tu plaza se cerrará y tendrás que contactarnos para abrirla de nuevo.\n\nUn saludo,\nProfesorado de cursos VGAFIB"
                        };
                    }
                    await client.SendAsync(mail);
                    await client.DisconnectAsync(true);
                }
                return View(true);
            }
            return View(false);
        }

    }
}
