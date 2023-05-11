using persona_crud.Models.Interfaces;

namespace persona_crud.Models
{
    public class RequestDTO : IRequestDTO
    {
        public object Value { get; set; }
    }
}
