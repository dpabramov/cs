using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemUpdateModel
    {
        [Required]
        public Guid Id { get; set; } //идентификатор объекта

        [Required]
        public ReminderItemStatus Status { get; set; }
    }
}
