namespace EHRNurse.Api.Dto
{
    public class NutritionListItemDto
    {
        public int NutritionId { get; set; }
        public int PatientId { get; set; }
        
        // C# 11+ required keyword
        public required string MealType { get; set; } // e.g., "Lunch", "Dinner", "Snack"
        public required string Description { get; set; } // e.g., "Grilled Chicken with Rice"
        
        public string? DietCode { get; set; } // e.g., "Diabetic", "Low Sodium", "NPO"
        public string? InstructionKitchen { get; set; } // e.g., "No nuts", "Pureed"
        
        public required string Status { get; set; } // "Served", "Pending", "NPO"
        public bool HasAllergyWarning { get; set; }
    }
}