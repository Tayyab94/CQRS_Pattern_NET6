using CQRS_PatternImplement.Repositories;
using MediatR;

namespace CQRS_PatternImplement.Features.Players.Commands
{
    public class DeletePlayerCommand:IRequest<int>
    {
        public int Id { get; set; }

        public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, int>
        {
            private readonly IPlayersService _playerService;

            public DeletePlayerCommandHandler(IPlayersService playerService)
            {
                _playerService = playerService;
            }

            public async Task<int> Handle(DeletePlayerCommand command, CancellationToken cancellationToken)
            {
                var player=await _playerService.GetPlayerById(command.Id);

                if(player is null)
                {
                    return default;
                }

                return await _playerService.DeletePlayer(player);
              
            }
        }
    }
}
