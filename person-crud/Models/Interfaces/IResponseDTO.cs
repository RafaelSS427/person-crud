namespace persona_crud.Models.Interfaces
{
    public interface IResponseDTO : IBaseResAndReqDTO
    {
        bool Ok { get; set; }
    }
}
