
using Microsoft.AspNetCore.Mvc;
using Model;
using Server.Services;
namespace Server.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class InfoCardsController : Controller
    {
        private readonly DataService Data;
        private List<InfoCard> cards;

        public InfoCardsController(DataService data)
        {
            Data = data;
            cards = Data.GetDataFromJson();
        }

        [HttpGet]
        public JsonResult Index()
        {
            try
            {
                Console.WriteLine("Данные отправлены!");
                return new JsonResult(cards);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        [HttpPost("Create")]
        public async void Create(InfoCard card)
        {
            try
            {
                cards.Add(card);
                await Data.RewriteJson(cards);
                Console.WriteLine("Карточка создана!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [HttpDelete("Delete/{id:int}")]
        public void Delete(int id)
        {
            try
            {
                InfoCard card = cards[id];
                cards.RemoveAt(id);
                Data.RewriteJson(cards);
                Console.WriteLine("Карточка удалена!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [HttpPut("Edit/{id:int}")]
        public void Update(int id, InfoCard card)
        {
            try
            {
                cards[id] = card;
                Data.RewriteJson(cards);
                Console.WriteLine("Карточка изменена!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
