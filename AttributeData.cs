namespace AutocadInitialization
{
    public class AttributeData
    {
        public string ClientHead { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string ClientLocation { get; set; }
        public string FirmName { get; set; }
        public string FirmLocation { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLocation { get; set; }
        public string Designer { get; set; }
        //public string Scale { get; set; }
        public string Date { get; set; }
        //public string DrawingTitle { get; set; }   
        public string DrawingNo { get; set; }
        public string SheetNo { get; set; }
        public bool isClientHead { get; set; } = true;
        public bool isDepartment { get; set; } = true;
        public bool isDivision { get; set; } = true;
        public bool isClientLocation { get; set; } = true;
        public bool isFirmName { get; set; } = true;
        public bool isFirmLocation { get; set; } = true;
        public bool isProjectName { get; set; } = true;
        public bool isProjectLocation { get; set; } = true;
        public bool isDesigner { get; set; } = true;
        public bool isDate { get; set; } = true;
        public bool isDrawingName { get; set; } = true;

    }
}
