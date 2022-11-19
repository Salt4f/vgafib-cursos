using VGAFIBCursos.Data;
using VGAFIBCursos.Models;

namespace VGAFIBCursos.Utils
{
    public class DBUtils
    {

        public static async Task InitDB(DataContext context)
        {
            Curso[] cursos =
            {
                new() {
                    Name = "Curso de prueba",
                    Description = "Esto es un curso de prueba\n¿Seguda línea?",
                    Image = "iVBORw0KGgoAAAANSUhEUgAAAK8AAAA7CAYAAAANZdogAAAFaUlEQVR4Xu2cL3TiQBDGty4SiUQiK5GVSCQSiaxEIpGVSGQlMrISWYmMRCLj7jKBzaW5/NnJzi6b8vFe3728DJPZb34ZJpPkXpRSf7I/fKDA4BR4AbyDyxkCvisAeIHCYBUAvINNHQIHvGBgsAoA3sGmDoEDXjAwWAUA70BTdz37CXw09XOcPkcBvH1UM/iOL7gMQrEy+ZXwIjntTPjSxxVcOn5X/q3OKNs5r6/kSCzykT5cJd81XK79S+Skd9vgenG+/EuI2ObDF7xpmoosJYqi3I9r/SWCfXp4TeHiJrNq7xqu3P96YsfEPlFPCa+X5NilJv923+SIwOsQLsDLgKO2sgw4OU0nXxPsvewHrA8DDW+mYm2D6zP/If5bfkZr4+Hac9PM9b/ZKTVZ1h8l+VRqt/m576nbhgFXFhEYJeFqALv1l6CqfymeqjvuernnmQ97t5U3E6/zUxZcMvnMysJNprR9p04VA6O2DfDWy2orHnn9DwAuvILJkYZRQp82oG39c9fLPbl82DuvvPpnrm4xgPffaIqbbMCrFOC9P3jCrUTS9k7gxQUb2gZSgFvpjOzb4JK4YOOeERbThtVoUnu0w9Xguocb593eeeXtjOuZL9g6xakYcK8JBP03udLQbmYLNZ6+qmh8gzi9JOpy/la70zHfdgGxW3gFxcOcNxMzMHgJ3MVorN4WaxW9zmqznX6f1Ndxr47Xy4/9EjAD3kf2vK5Pboc9L4FL1XbytlBqPO5cCUH8ftjm3zmfTznMtgADXp/wdqa4YtBy08GopxYcJZYj66q48Xb1oxrrbV2BP1bbohrbAOwWXpObFJV8se4gCVYW6ekB90GeKtfS8dj6r8JLAOb9bV3VXU7UejxV+4/49rX7Nn2Hqi/9q/vhoOFtm/O2FSLflUUaltDg5erZFH9X1aWcRqvbz1l6uL1oV2zvvlS83+QtA/XKtq2D88oLeLm9ws3e9cnE9a9XcZzM1HQ6u00WGi7S1u/zvJ/V8BbbGbzJ11FsAuEN3r6vDemHxblih2bPRTjE+Knq5u1CA7R6jdTjLpJTAW+xncFLIzRqHWzaBX0cwGt4wWbbM7If1g/swaJiurBcd56Hyec+r6665y22N4dhw9v3tZtHVyIReH0/MsqdC7fYm1RdGodF8VWl81E+TZhvD7cW6D7rnUdLlUySHOxBVt5Bwet6mtFZwyoGgjByi0HdXLeA8g6pyXJ0FQa8rpNpko2yDTceaf81/qReYyLXGmC6WNOjrn3WCjTepLhc8umCrsDqvm07ZXhYzzuoyusBLu4hHvUCqYa3HC9dvNGncd5bNs7A1ZMGiapLrmUv2BhnflfSTF8dl6osrp+d6Fovdz93jmxrT1V3fo1UNBkp6l3pE6ef+Z00/amFOINWP6TzHccqHt3+fwkJgMXg7RLfVjzX/tnTgIaA+lbGrvVV9/cdPXKPQ7+UGtzFNAN1M89e3LzfOasBuM4/tRgaXImbE+JtQ5coocPbFT93vy+4uHFx7TW8BJ2uuFUfVIHpxkXdRz+EQ/vIR5pc8+obROXtI4bJd3wl37QHN4m5bDP0+MtrKbcMdTpoIE01kgCXjmXdNpgGrO1MYfGVfG78XHvT9XL9+rZvelNCxyEFJGddveHlHCREW18nx2+BN8QcPi28ISYDMfEUALw8vWAdkAKAN6BkIBSeAoCXpxesA1IA8AaUDITCUwDw8vSCdUAKAN6AkoFQeAoAXp5esA5IAcAbUDIQCk8BwMvTC9YBKQB4A0oGQuEpAHh5esE6IAUAb0DJQCg8BQAvTy9YB6QA4A0oGQiFpwDg5ekF64AUALwBJQOh8BQAvDy9YB2QAn8BO95OW+QLtx4AAAAASUVORK5CYII=",
                },
                new() {
                    Name = "Curso de prueba",
                    Description = "Esto es un curso de prueba\n¿Seguda línea?",
                    Image = "iVBORw0KGgoAAAANSUhEUgAAAK8AAAA7CAYAAAANZdogAAAFaUlEQVR4Xu2cL3TiQBDGty4SiUQiK5GVSCQSiaxEIpGVSGQlMrISWYmMRCLj7jKBzaW5/NnJzi6b8vFe3728DJPZb34ZJpPkXpRSf7I/fKDA4BR4AbyDyxkCvisAeIHCYBUAvINNHQIHvGBgsAoA3sGmDoEDXjAwWAUA70BTdz37CXw09XOcPkcBvH1UM/iOL7gMQrEy+ZXwIjntTPjSxxVcOn5X/q3OKNs5r6/kSCzykT5cJd81XK79S+Skd9vgenG+/EuI2ObDF7xpmoosJYqi3I9r/SWCfXp4TeHiJrNq7xqu3P96YsfEPlFPCa+X5NilJv923+SIwOsQLsDLgKO2sgw4OU0nXxPsvewHrA8DDW+mYm2D6zP/If5bfkZr4+Hac9PM9b/ZKTVZ1h8l+VRqt/m576nbhgFXFhEYJeFqALv1l6CqfymeqjvuernnmQ97t5U3E6/zUxZcMvnMysJNprR9p04VA6O2DfDWy2orHnn9DwAuvILJkYZRQp82oG39c9fLPbl82DuvvPpnrm4xgPffaIqbbMCrFOC9P3jCrUTS9k7gxQUb2gZSgFvpjOzb4JK4YOOeERbThtVoUnu0w9Xguocb593eeeXtjOuZL9g6xakYcK8JBP03udLQbmYLNZ6+qmh8gzi9JOpy/la70zHfdgGxW3gFxcOcNxMzMHgJ3MVorN4WaxW9zmqznX6f1Ndxr47Xy4/9EjAD3kf2vK5Pboc9L4FL1XbytlBqPO5cCUH8ftjm3zmfTznMtgADXp/wdqa4YtBy08GopxYcJZYj66q48Xb1oxrrbV2BP1bbohrbAOwWXpObFJV8se4gCVYW6ekB90GeKtfS8dj6r8JLAOb9bV3VXU7UejxV+4/49rX7Nn2Hqi/9q/vhoOFtm/O2FSLflUUaltDg5erZFH9X1aWcRqvbz1l6uL1oV2zvvlS83+QtA/XKtq2D88oLeLm9ws3e9cnE9a9XcZzM1HQ6u00WGi7S1u/zvJ/V8BbbGbzJ11FsAuEN3r6vDemHxblih2bPRTjE+Knq5u1CA7R6jdTjLpJTAW+xncFLIzRqHWzaBX0cwGt4wWbbM7If1g/swaJiurBcd56Hyec+r6665y22N4dhw9v3tZtHVyIReH0/MsqdC7fYm1RdGodF8VWl81E+TZhvD7cW6D7rnUdLlUySHOxBVt5Bwet6mtFZwyoGgjByi0HdXLeA8g6pyXJ0FQa8rpNpko2yDTceaf81/qReYyLXGmC6WNOjrn3WCjTepLhc8umCrsDqvm07ZXhYzzuoyusBLu4hHvUCqYa3HC9dvNGncd5bNs7A1ZMGiapLrmUv2BhnflfSTF8dl6osrp+d6Fovdz93jmxrT1V3fo1UNBkp6l3pE6ef+Z00/amFOINWP6TzHccqHt3+fwkJgMXg7RLfVjzX/tnTgIaA+lbGrvVV9/cdPXKPQ7+UGtzFNAN1M89e3LzfOasBuM4/tRgaXImbE+JtQ5coocPbFT93vy+4uHFx7TW8BJ2uuFUfVIHpxkXdRz+EQ/vIR5pc8+obROXtI4bJd3wl37QHN4m5bDP0+MtrKbcMdTpoIE01kgCXjmXdNpgGrO1MYfGVfG78XHvT9XL9+rZvelNCxyEFJGddveHlHCREW18nx2+BN8QcPi28ISYDMfEUALw8vWAdkAKAN6BkIBSeAoCXpxesA1IA8AaUDITCUwDw8vSCdUAKAN6AkoFQeAoAXp5esA5IAcAbUDIQCk8BwMvTC9YBKQB4A0oGQuEpAHh5esE6IAUAb0DJQCg8BQAvTy9YB6QA4A0oGQiFpwDg5ekF64AUALwBJQOh8BQAvDy9YB2QAn8BO95OW+QLtx4AAAAASUVORK5CYII=",
                },
            };
            await context.AddRangeAsync(cursos);
            await context.SaveChangesAsync();

            var curso = context.Cursos!.FirstOrDefault();

            Estudiante[] estudiantes =
            {
                new()
                {
                    Dni = "12345678Z",
                    Nombre = "Pepito",
                    Apellidos = "Grillo",
                    Email = "email@email.com",
                    FechaInscripcion = DateTime.UtcNow,
                    Curso = curso,
                },
            };
            await context.AddRangeAsync(estudiantes);
            await context.SaveChangesAsync();
        }

    }
}
