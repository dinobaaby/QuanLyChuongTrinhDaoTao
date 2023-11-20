using System.ComponentModel.DataAnnotations;

namespace MachineLearningBTL.Models
{
    public class DiaBetes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Pregnancies { get; set; }
        [Required]
        public int Glucose { get; set; }
        [Required]
        public int BloodPressure { get; set; }
        [Required]
        public int SkinThickness { get; set; }
        [Required]
        public int Insulin {  get; set; }
        [Required]
        public float BMI {  get; set; }
        [Required]
    
        public float DiabetesPedigreeFunction { get; set; }
        [Required]
     
        public int Age {  get; set; }
        [Required]
    
        public int Outcome { get; set; }

    }
}
