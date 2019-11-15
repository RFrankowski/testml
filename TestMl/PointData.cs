using Microsoft.ML.Data;
using System.ComponentModel.DataAnnotations;

namespace TestMl
{
    public class PointData
    {
        [Key]
        public int id { get; set; }

        [LoadColumn(0)]
        public string Label { get; set; }

        [LoadColumn(1)]
        public float x_pos { get; set; }

        [LoadColumn(2)]
        public float y_pos { get; set; }


    }
}
