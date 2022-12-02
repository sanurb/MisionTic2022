namespace MudBlazorTest.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Moock Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propietario>().HasData(
                new Propietario
                {
                    PersonaId = 1,
                    Nombres = "David Santiago",
                    Apellidos = "Urbano Rivadeneira",
                    Telefono = "+573158880482",
                    Direccion = "Calle 63# 4-52, Cali, Valle",
                },

                new Propietario
                {
                    PersonaId = 2,
                    Nombres = "Sofia",
                    Apellidos = "Urbano Rivadeneira",
                    Telefono = "+573168880482",
                    Direccion = "Calle 63# 4-52, Cali, Valle",
                }
            );

            modelBuilder.Entity<Perro>().HasData(
                new Perro
                {
                    PerroId = 1,
                    Afiliacion = true,
                    Color = "Blanco con dorado",
                    Raza = "Beagle",
                    Nombre = "Isis",
                    Sexo = "Hembra",
                    PropietarioId = 1
                },
                new Perro
                {
                    PerroId = 2,
                    Afiliacion = false,
                    Color = "Blanco con dorado",
                    Raza = "Bulldog",
                    Nombre = "Valentino",
                    Sexo = "Macho",
                    PropietarioId = 2
                }
            );

            modelBuilder.Entity<Veterinario>().HasData(
                new Veterinario
                {
                    PersonaId = 1,
                    Nombres = "Pepito",
                    Apellidos = "Perez",
                    Telefono = "+573158880482",
                    TarjetaProfesional = "123456"
                },

                new Veterinario
                {
                    PersonaId = 2,
                    Nombres = "Juan",
                    Apellidos = "Gomez",
                    Telefono = "+573168880482",
                    TarjetaProfesional = "953456"
                }
            );

            //modelBuilder.Entity<Visita>().HasData(
            //    new Visita
            //    {
            //        Id = 1,
            //        Temperatura = "15c",
            //        Peso = 23.4,
            //        VeterinarioId = 1,
            //        Recomendaciones = "meter en arroz",
            //        HistoriaId = 1,

            //    }
            //);


            //modelBuilder.Entity<Visita>().HasData(
            //    new Historia
            //    {
            //        HistoriaId = 1,
            //        fechaApertura = new DateTime()
            //    }
            //);
        }
        public DbSet<Perro> Perros { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        //public DbSet<Visita> Visitas { get; set; }
        public DbSet<Historia> Historias { get; set; }


    }
}
