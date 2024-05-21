namespace GeoDart.Models
{
    public class DrillingData
    {
        public int Id { get; set; }//Id Записи
        public DateTime DateTime { get; set; } //Время записи
        public float WaterPressurte { get; set; } // Давление Воды
        public float WaterConsumption { get; set; } // Расход Воды
        public float FeedIn { get; set; }
        public float FeedOut { get; set; }
        public float Temperature {  get; set; } // температура
    }
}
