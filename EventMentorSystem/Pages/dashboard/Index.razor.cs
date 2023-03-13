using EMS.DB.Models;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMentorSystem.Pages.dashboard
{
    public partial class Index
    {
        private MudDateRangePicker _picker;
        private DateRange _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.AddDays(5).Date);
        private bool _autoClose;
        private string searchString = "";
        private string searchString1 = "";
        private int Totalevent;
        private int Totaluser;
        private int Totalservice;
        private DateTime? startDate;
        private DateTime? endDate;
        private List<Event> eventList = new();
        private List<User> userlist = new();
        private List<CategoryService> categoryservicelist = new();
        private IEnumerable<Event> pagedData;
        private IEnumerable<EventStaffWork> EventStaffWorkpagedData;
        private MudTable<Event> tableRef;
        private MudTable<EventStaffWork> tableRefEventStaffWork;
        private int totalItems;
        private int totalItemsOperator;
        private List<EventStaffWork> EventStaffWorkList = new();



        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                GetAllevents();
                GetUserList();
                GetList();
            }

            return base.OnAfterRenderAsync(firstRender);
        }

        private List<Event> GetAllevents()
        {
            eventList = _EventRepository.GetList();
            Totalevent = eventList.Count();
            StateHasChanged();
            return eventList;
        }

        //private List<User> GetUsers1()
        //{
        //    Totaluser = userlist.Count();
        //    StateHasChanged();
        //    return userlist;
        //}

        private List<User> GetUserList()
        {
            userlist = _UserRepository.GetAllUser();
            Totaluser = userlist.Count();
            StateHasChanged();
            return userlist;
        }
        private List<CategoryService> GetList()
        {
            categoryservicelist = _CategoryServiceRepository.GetList();
            Totalservice = categoryservicelist.Count();
            StateHasChanged();
            return categoryservicelist;

        }

        private List<EventStaffWork> GetAllOperatorWork()
        {
            EventStaffWorkList = _EventStaffWorkRepository.GetEventStaffWorkList();
            return EventStaffWorkList;
        }



        private bool Search(Event events)
        {
            if (StringValid(events.EventName)
                && StringValid(events.OperatorName)
                && StringValid(events.EventVenue)
                && StringValid(events.OrganizerName)
                && StringValid(events.OrganizerContact)
                && StringValid(events.FromDate.ToString())

                &&
                events.EventName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || events.OperatorName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || events.EventVenue.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || events.OrganizerName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || events.OrganizerContact.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || events.FromDate.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private bool SearchforOperatorwork(EventStaffWork EventStaffWorks)
        {
            if (StringValid(EventStaffWorks.Status)
                && StringValid(EventStaffWorks.Status)
                && StringValid(EventStaffWorks.Description)
                && StringValid(EventStaffWorks.Service)
                && StringValid(EventStaffWorks.Event.EventName)
                && StringValid(EventStaffWorks.Event.EventVenue)
                && StringValid(EventStaffWorks.Event.FromDate.ToString())

                &&
                   EventStaffWorks.Status.Contains(searchString1, StringComparison.OrdinalIgnoreCase)
                || EventStaffWorks.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase)
                || EventStaffWorks.Service.Contains(searchString1, StringComparison.OrdinalIgnoreCase)
                || EventStaffWorks.Event.EventName.Contains(searchString1, StringComparison.OrdinalIgnoreCase)
                || EventStaffWorks.Event.EventVenue.Contains(searchString1, StringComparison.OrdinalIgnoreCase)
                || EventStaffWorks.Event.FromDate.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private bool StringValid(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                return true;
            }

            return false;
        }



        private List<Event> GetEventListFromDashBoard(DateTime? startDate, DateTime? endDate)
        {
            UpdateDashboardData();
            if (startDate.HasValue && endDate.HasValue)
            {
                return _EventRepository.GetListFromDashboard(startDate, endDate);
            }
            else
            {
                //get all data of current month
                return _EventRepository.GetList();
            }
        }

        /// <summary>
        /// Here we simulate getting the paged, filtered and ordered data from the server
        /// </summary>
        private async Task<TableData<Event>> ServerReload(TableState state)
        {
            IEnumerable<Event> data;
            if (startDate.HasValue && endDate.HasValue)
            {
                data = _EventRepository.GetListFromDashboard(startDate, endDate);
            }
            else
            {
                //get all data of current month
                data = _EventRepository.GetList();
            }

            data = data.Where(selectedModel => { return Search(selectedModel); }).ToArray();
            data = data.OrderByDirection(state.SortDirection, o => o.FromDate.Value);
            totalItems = data.Count();

            pagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();
            return new TableData<Event>() { TotalItems = totalItems, Items = pagedData };
        }
        private async Task<TableData<EventStaffWork>> ServerReload1(TableState state)
        {
            IEnumerable<EventStaffWork> data;
            if (startDate.HasValue && endDate.HasValue)
            {
                data = _EventStaffWorkRepository.GetListFromWork(startDate, endDate);
            }
            else
            {
                //get all data of current month
                data = _EventStaffWorkRepository.GetEventStaffWorkList();
            }

            data = data.Where(selectedModel => { return SearchforOperatorwork(selectedModel); }).ToArray();
            data = data.OrderByDirection(state.SortDirection, o => o.Event.FromDate.Value);
            totalItemsOperator = data.Count();

            EventStaffWorkpagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();
            return new TableData<EventStaffWork>() { TotalItems = totalItemsOperator, Items = EventStaffWorkpagedData };
        }
        private Task UpdateDashboardData()
        {
            if (_dateRange is not null)
            {
                startDate = _dateRange.Start;
                endDate = _dateRange.End;
            }
            else
            {
                startDate = null;
                endDate = null;
            }
            tableRef.ReloadServerData();
            tableRefEventStaffWork.ReloadServerData();
            return Task.CompletedTask;
        }

        private void OnSearch(string text)
        {
            searchString = text;
            tableRef.ReloadServerData();

        }
        private void OnSearchOperator(string text)
        {
            searchString1 = text;
            tableRefEventStaffWork.ReloadServerData();
        }
    }
}
