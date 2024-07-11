using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Base.Response
{
	public class ApiResponse
	{
		public string Message { get; set; }
		public bool IsSuccess { get; set; }
		public DateTime ServerDate { get; set; } = DateTime.UtcNow;
		public Guid ReferenceNumber { get; set; } = Guid.NewGuid();

		public ApiResponse(string message = null)
		{
			if (string.IsNullOrEmpty(message))
			{
				IsSuccess = true;
			}
			else
			{
				IsSuccess = false;
				Message = message;
			}
		}
	}

	public partial class ApiResponse<T>
	{
		public T Data { get; set; }
		public string Message { get; set; }
		public bool IsSuccess { get; set; }
		public DateTime ServerDate { get; set; } = DateTime.UtcNow;
		public Guid ReferenceNumber { get; set; } = Guid.NewGuid();

		public ApiResponse(T data)
		{
			Data = data;
			Message = "Success";
			IsSuccess = true;
		}

		public ApiResponse(bool isSuccess)
		{
			Data = default;
			IsSuccess = isSuccess;
			Message = isSuccess ? "Success" : "Error";
		}

		public ApiResponse(string error)
		{
			Data = default;
			IsSuccess = false;
			Message = error;
		}
	}
}
