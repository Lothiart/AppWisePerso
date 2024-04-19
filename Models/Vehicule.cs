namespace Models
{
    public class Vehicule
    {
        public int Id { get; set; }
        public string Registration {  get; set; }
        public int NbPlaces {  get; set; }
        public int CO2 { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int MotorId { get; set; }
        public Motor Motor { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
