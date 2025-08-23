

namespace ClinicManager.Core.Common
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public List<T> Data { get; private set; }

        private Result(bool success, string message, List<T> data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static Result<T> SuccessResult(List<T> data, string message = "")
            => new Result<T>(true, message, data);

        // Overload for single item
        public static Result<T> SuccessResult(T item, string message = "")
            => new Result<T>(true, message, new List<T> { item });

        public static Result<T> Failure(string message)
            => new Result<T>(false, message, new List<T>());
    }
}
