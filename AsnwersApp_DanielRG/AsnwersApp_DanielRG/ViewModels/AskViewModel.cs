using AsnwersApp_DanielRG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AsnwersApp_DanielRG.ViewModels
{
    public class AskViewModel : BaseViewModel
    {
        public Ask MyAsk { get; set; }

        public AskStatus MyAskStatus { get; set; }
        public AskViewModel() 
        {
            MyAsk = new Ask();
            MyAskStatus = new AskStatus();
        }

        public async Task<List<AskStatus>> GetAksStatusAsync()
        {
            try
            {
                List<AskStatus> askStatuses = new List<AskStatus>();
                askStatuses = await MyAskStatus.GetAskStatus();

                if (askStatuses == null)
                {
                    return null;
                }

                return askStatuses;
            }
            catch (Exception e)
            {
                string msg = e.Message;

                return null;

                throw;
            }
        }

        public async Task<bool> AddUserAsync(DateTime pTiempo, string pAsk, int pUserId,int pAskSta, string pImageURL, string pDetail)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
               MyAsk.Date = pTiempo;
                MyAsk.Ask1 = pAsk;
                MyAsk.UserId = pUserId;
                MyAsk.ImageUrl = pImageURL;
                MyAsk.AskDetail = pDetail;
                MyAsk.AskStatusId = pAskSta;


                bool R = await MyAsk.AddAskAsync();

                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<ObservableCollection<Ask>> GetAsksByAsync()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Ask> asks = new ObservableCollection<Ask>();

                asks = await MyAsk.GetAsksByAskStatus();

                if (asks == null)
                { return null; }
                return asks;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }



    }
}
