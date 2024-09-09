namespace CarRental.BussinessLayer.Interfaces
{
    public interface IDapperConfiguration
    {
        public void ConfigureGuidToStringMapping();
        public void SetCustomMappingForEntities();
    }
}
