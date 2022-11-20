namespace CleanArchitecture.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public CodeErrorResponse(int statusCode, string? errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El request enviado tiene errores",
                401 => "Carece de autorizacion para este recurso",
                404 => "No se encontro el recurso solicitado",
                500 => "Errores en el servidor",
                _ => string.Empty,
               
            };
        }
    }
}
