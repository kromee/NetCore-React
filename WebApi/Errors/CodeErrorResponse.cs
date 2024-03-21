using System;
namespace WebApi.Errors
{
	public class CodeErrorResponse
	{
		public CodeErrorResponse(int statuscode, string menssage = null) {
            StatusCode = statuscode;
			Message = menssage ?? getDafautMessageStatusCode(statuscode);


		}

		private string getDafautMessageStatusCode(int statuscode) {
			return statuscode switch
			{
				400 => "El Resquest enviado tiene errores",
				401 => "No tienes permisos para este recurso",
				404 => "No se encontró el recurso solicitado",
				500 => "Se no se pudo procesar la información en el servidor",
				_ => null
			};
		}



        public int StatusCode { get; set; }
		public string Message { get; set; }

	}
}

