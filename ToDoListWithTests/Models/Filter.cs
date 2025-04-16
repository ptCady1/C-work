namespace ToDoList.Models
{
	public class Filter
	{
		public Filter(string filterstring)
		{
			FilterString = filterstring ?? "all-all-all";
			string[] filter = FilterString.Split('-');
			PointId = filter[0];
			StatusId = filter[1];
		}
		public string FilterString { get;}
		public string StatusId { get;}
		public string PointId { get;}

		public bool HasStatus => StatusId.ToLower() != "all";
		public bool HasPoint => PointId.ToLower() != "all";

		//public static Dictionary<string, string> DueFilterValues =>
		//	new Dictionary<string, string>
			//{
//
			//}
	}
}
