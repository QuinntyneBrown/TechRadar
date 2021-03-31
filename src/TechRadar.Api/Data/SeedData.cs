namespace TechRadar.Api.Data
{
    public static class SeedData
    {
        public static void Seed(TechRadarDbContext context)
        {
            BlipConfiguration.Seed(context);
        }

        internal static class BlipConfiguration
        {
            internal static void Seed(TechRadarDbContext context)
            {

            }
        }
    }
}
