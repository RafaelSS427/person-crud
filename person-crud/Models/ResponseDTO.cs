using persona_crud.Models.Interfaces;

namespace persona_crud.Models
{
    public class ResponseDTO : IResponseDTO
    {
        public object Value { get; set; }
        public bool Ok { get; set; }
    }
}
