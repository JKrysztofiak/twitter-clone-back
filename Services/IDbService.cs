using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone
{
	public interface IDbService
	{

		public IEnumerable<Messages> GetMessages();
		public Messages GetMessageById(int id);
		public Messages AddMessage(MessageDTO message);
		public void DeleteMessage(int id);
	}
}
