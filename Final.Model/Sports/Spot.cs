
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Exam.Domain.Sports
{
	public class Spot
	{
		[Key]
		public int Registration_Id { get; set; } = 0;
		public int Age { get; set; } = 0;
		[Required]
		public string Applicant_name { get; set; } = null;
		public string Email { get; set; } = null;
		public string Mobile_no { get; set; } = null;
		public string image_path { get; set; } = null;

		public string Gender { get; set; } = null;

		public string dob { get; set; }


		public int club_id { get; set; } = 0;//
		public int sport_Id { get; set; } = 0;//
		[NotMapped]
		public string? sprot_name { get; set; } = "";

		[NotMapped]
		public string? club_name { get; set; } = "";
		
		

	}
	public class SportEntity
    {
		public int sport_Id { get; set; } = 0;//
		public string sprot_name { get; set; } = null;
	}
}