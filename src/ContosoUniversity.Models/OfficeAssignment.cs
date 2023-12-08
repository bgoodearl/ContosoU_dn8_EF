//using Ardalis.GuardClauses;
using ContosoUniversity.Models.Lookups;
using CU.Definitions.Lookups;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private OfficeAssignment()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            OBLTId = (short)CULookupTypes.OfficeBuildingType;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OfficeAssignment(Instructor instructor, string location)
            : base()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            //Guard.Against.Null(instructor, nameof(instructor));
            //Guard.Against.Zero(instructor.ID, "instructor.ID");
            //Guard.Against.NullOrWhiteSpace(location, nameof(location));
            Instructor = instructor;
            InstructorID = instructor.ID;
            Location = location;
        }

        //[Key]
        //[ForeignKey("Instructor")]
        public int InstructorID { get; set; }

        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; } = string.Empty;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public virtual Instructor Instructor { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string? OfficeBuildingCode { get; set; }
        public short? OBLTId { get; set; }
        public virtual OfficeBuilding? Building { get; set; }
    }
}
