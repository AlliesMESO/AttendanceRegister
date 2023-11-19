namespace AttendanceRegister.Models.ViewModels
{
    public class AttendanceReportViewModel
    {
        public string ClassName { get; set; }
        public int Grade { get; set; }
        public string StudentName { get; set; }
        public int ClassesAttended { get; set; }
        public int ClassesMissed { get; set; }
    }
}
