using CQRS_PatternImplement.Features.Players.Commands;
using CQRS_PatternImplement.Features.Players.Queries;
using CQRS_PatternImplement.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CQRS_PatternImplement.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IMediator _mediator;


        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;            
        }


        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllPlayersQuery()));
        }

        public async Task<IActionResult> Details(int id)
            {
            return View(await _mediator.Send(new GetPlayerByIdQuery() { Id = id }));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePlayerCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  //  await _mediator.Send(new CreatePlayerCommand() { Appearances= command.Appearances.Value, Goals= command.Goals.Value, Name= command.Name, ShirtNo= command.ShirtNo.Value });
                    //await _mediator.Send(new Player() { Appreaances = command.Appearances.Value, Name = command.Name, Goals = command.Goals.Value, ShirtNo = command.ShirtNo.Value });
                    await _mediator.Send(command);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Unable to save changes.");
               
            }

            return View(command);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _mediator.Send(new GetPlayerByIdQuery() { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, UpdatePlayerCommand command)
        {
            if(id!= command.Id)
                return BadRequest();

            try
            {
                if(ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Unable to save changes.");

            }

            return View(command);
        }

        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeletePlayerCommand() { Id = id });

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Unable to delete. ");

                
            }

            return RedirectToAction(nameof(Index)); 
        }
    }
}
