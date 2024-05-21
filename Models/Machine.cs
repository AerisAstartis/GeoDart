namespace GeoDart.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string? Name { get; set; } = "";//Станок №
        public string? Customer { get; set; } = "";// Заказчик
        public string? Contractor { get; set; } = "";// Подрядчик
        public string? Well { get; set; } = ""; //Скважина
        public string? Cluster { get; set; } = ""; // Куст
        public string? Drilling { get; set; } = ""; // Буровая
        //public DateTime CurrentTime {  get; set; } // Время
        public string? State { get; } // статус бурения
        public float WaterPressurte { get; set; } // Давление Воды
        public float WaterConsumption { get; set; } // Расход Воды
        public float FeedIn { get; set; }
        public float FeedOut { get; set; }

    }
}
