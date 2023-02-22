using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommand : CarWorkshopServiceDto, IRequest
    {
        public string CarWorkshopEncodedName { get; set; } = default!;
    }
}
