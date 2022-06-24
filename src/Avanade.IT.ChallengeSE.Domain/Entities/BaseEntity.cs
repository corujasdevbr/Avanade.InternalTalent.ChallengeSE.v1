using Flunt.Notifications;

namespace Avanade.IT.ChallengeSE.Domain.Entities
{
    public abstract  class BaseEntity : Notifiable<Notification>
    {
        protected BaseEntity() => Id = Guid.NewGuid();

        public Guid Id { get; protected set; }
        public bool Active { get; protected set; }
        public DateTime DateCreated { get; protected set; }
        public DateTime DateAltered { get; protected set; }

        public void ChangeStatus()
        {
            Active = !Active;
        }
    }
}
