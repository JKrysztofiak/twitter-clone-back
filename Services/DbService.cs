using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone
{
	public class DbService : IDbService
	{

		private twittercloneContext db;

		public DbService(twittercloneContext context)
		{
			db = context;
		}

		public IEnumerable<Messages> GetMessages()
		{
			return db.Messages.OrderByDescending(x => x.Messageid).ToArray<Messages>();
		}

		public Messages GetMessageById(int id)
		{
			return db.Messages.First<Messages>(x => x.Messageid == id);
		}

		public Messages AddMessage(MessageDTO message)
		{
			int id = db.Messages.Max<Messages>(x => x.Messageid)+1;
			Console.WriteLine("New id: " + id);
			Console.WriteLine("For user: " + message.username);

			var tmpMessage = new Messages{
				Messageid = id,
				Messagetext = message.messageText,
				Username = message.username
			};

			db.Messages.Add(tmpMessage);
			db.SaveChanges();
			return tmpMessage;
		}

		public void DeleteMessage(int id)
		{
			Console.WriteLine("DELETING MSG: " + id);
			var msg = db.Messages.FirstOrDefault<Messages>(x => x.Messageid == id);
			db.Messages.Remove(msg);
			db.SaveChanges();
		}

		public void UpdateMessage(int id, MessageUpdateDTO text)
		{
			Console.WriteLine("UPDATING MSG: " + id);
			var msg = db.Messages.FirstOrDefault<Messages>(x => x.Messageid == id);
			if(msg.Messageid == id)
			{
				msg.Messagetext = text.messageText;
			}
			//db.Messages.Update(msg);
			db.SaveChanges();
		}
	}
}
