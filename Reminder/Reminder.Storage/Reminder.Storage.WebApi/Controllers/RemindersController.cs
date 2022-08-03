using Microsoft.AspNetCore.Mvc;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.Storage.WebApi.Controllers
{
    [ApiController]
    [Route("api/reminders")]
    public class RemindersController : ControllerBase
    {
        private IReminderStorage _reminderStorage;

        public RemindersController(IReminderStorage reminderStorage)
        {
            _reminderStorage = reminderStorage;
        }

        [HttpPost]
        public IActionResult AddReminderItem([FromBody] ReminderItemAddModel AddModel)
        {
            if (AddModel == null || !ModelState.IsValid)
                return BadRequest(ModelState);


            Guid id = _reminderStorage.Add(AddModel.Date,
                                            AddModel.Message,
                                            AddModel.ContactId,
                                            ReminderItemStatus.Awaiting);

            return Created($"{id}", new ReminderItemGetModel(_reminderStorage.Get(id)));
        }

        [HttpGet("{id}")]
        public IActionResult GetReminderItem(Guid id)
        {
            if (id == default(Guid))
            {
                ModelState.AddModelError("id", "Must be present");
                return BadRequest(ModelState);
            }

            ReminderItem reminderItem = _reminderStorage.Get(id);

            if (reminderItem == null)
                return NotFound($"{id}");

            return Ok(new ReminderItemGetModel(reminderItem));
        }

        [HttpGet]
        public IActionResult GetReminderItem([FromQuery(Name = "[filter]status")] ReminderItemStatus reminderItemStatus)
        {
            List<ReminderItem> reminderItems = _reminderStorage.Get(reminderItemStatus);

            if (reminderItems == null)
                return NotFound();

            List<ReminderItemGetModel> result = reminderItems.Select(ri => new ReminderItemGetModel(ri)).ToList();

            return Ok(result);
        }

        [HttpPatch]
        public IActionResult UpdateReminderItem([FromBody] ReminderItemUpdateModel UpdateModel)
        {
            if (UpdateModel.Id == default(Guid))
            {
                ModelState.AddModelError("id", "Must be present");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("UpdateModel", "Must be fill in corectly");
                return BadRequest(ModelState);
            }

            if (_reminderStorage.Get(UpdateModel.Id) == null)
                return NotFound();

            //ri.Status = UpdateModel.Status;
            _reminderStorage.Update(UpdateModel.Id, UpdateModel.Status);

            ReminderItem ri = _reminderStorage.Get(UpdateModel.Id);

            return Ok(new ReminderItemGetModel(ri));
        }
    }
}
