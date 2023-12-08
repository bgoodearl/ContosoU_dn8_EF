using CU.Definitions.Lookups;

namespace ContosoUniversity.Models.Lookups
{
    public class OfficeBuilding : LookupBaseWith2cKey
    {
        public OfficeBuilding()
        {
            LookupTypeId = (short)CULookupTypes.OfficeBuildingType;
        }

        private ICollection<OfficeAssignment>? _officeAssignments;
        public virtual ICollection<OfficeAssignment> OfficeAssignments
        {
            get { return _officeAssignments ?? (_officeAssignments = new List<OfficeAssignment>()); }
            protected set { _officeAssignments = value; }
        }

    }
}
