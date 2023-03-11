using EMS.DB.Models;
using EMS.DB.Repository.Interface;
using EventMentorSystem.Data;
using EventMentorSystem.Pages.PaymentM;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMentorSystem.Pages.EventM
{
    public partial class UpdateAndViewEvent
    {
        [Parameter]
        public string EventId { get; set; }

        [CascadingParameter(Name = "cascadeParameters")]
        public GlobalParameter _parameters { get; set; }
        [Inject] IEventRepository _EventRepository { get; set; }
        [Inject] IEventCategoryRepository _EventCategoryRepository { get; set; }
        [Inject] ICategoryServiceRepository _CategoryServiceRepository { get; set; }
        [Inject] IStaffRepository _StaffRepository { get; set; }
        [Inject] IEventStaffWorkRepository _EventStaffWorkRepository { get; set; }
        [Inject] IPaymentRepository _PaymentRepository { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        private CategoryService CategoryServiceModel = new();
        private List<CategoryService> ServiceList = new();
        private List<CategoryService> eventservicelist = new();
        private List<EventStaffWork> EventStaffWorklist = new();
        private List<EventCategory> EventCategoryList = new();
        private List<Staff> StaffList = new();
        private List<Payment> PaymentList = new();
        private List<Event> eventList = new();
        private Event EventModel = new();
        private Payment PaymentModel = new();
        private EventCategory EventCategoryName = new();
        private long staffId { get; set; }
        List<String> selectedServiceList = new List<string>();
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                EventModel = _EventRepository.GetById(Convert.ToInt64(EventId));
                PaymentModel = _PaymentRepository.GetByEventId(Convert.ToInt64(EventId));
                EventCategoryName = _EventCategoryRepository.GetById(EventModel.CategoryId);
                GetEventCategoryList();
                GetAll();
                GetAllevents();
                GetByEventId();
                GetAllPaymentsByEventId(EventId);
                StateHasChanged();
            }

            return base.OnAfterRenderAsync(firstRender);
        }
        private List<CategoryService> GetAll()
        {
            ServiceList = _CategoryServiceRepository.GetList();
            return ServiceList;
        }
        private List<Staff> Getstaff()
        {
            StaffList = _StaffRepository.GetById(staffId);
            return StaffList;
        }
        private List<EventStaffWork> GetEventStaffWork()
        {
            EventStaffWorklist = _EventStaffWorkRepository.GetListFromEvent(Convert.ToInt64(EventId));
            return EventStaffWorklist;
        }

        private void GetEventCategoryList()
        {
            EventCategoryList = _EventCategoryRepository.GetList();
        }

        private List<Event> GetAllevents()
        {
            eventList = _EventRepository.GetList();

            return eventList;
        }

        public List<Payment> GetByEventId()
        {

            return PaymentList.Where(x => x.EventId == Convert.ToInt64(EventId)).ToList();
        }

        public void OnEventCategoryChange(long selectedEventCategoryId)
        {
        }
        private void EditEventSelectService(Event events)
        {
            var parameters = new DialogParameters();
            parameters.Add("EventModel", events);
            parameters.Add("_parameters", _parameters);
            var options = new DialogOptions()
            {
                CloseOnEscapeKey = false,
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                Position = DialogPosition.TopCenter,
                DisableBackdropClick = true
            };
            DialogService.Show<AddEventService>("Add Service", parameters, options);

        }
        private void EditEventDetails(Event events)
        {
            var parameters = new DialogParameters();
            parameters.Add("EventModel", events);
            parameters.Add("_parameters", _parameters);
            var options = new DialogOptions()
            {
                CloseOnEscapeKey = false,
                CloseButton = true,
                MaxWidth = MaxWidth.Large,
                Position = DialogPosition.TopCenter,
                DisableBackdropClick = true
            };
            DialogService.Show<EditEvent>("Update Event", parameters, options);
        }

        List<Payment> GetAllPaymentsByEventId(string eventId)
        {
            PaymentList = _PaymentRepository.GetPaymentListByEventId(Convert.ToInt64(eventId));
            return PaymentList;
        }

        string ValidCurrency(string value) => string.Format("₹ {0:#.00}", Convert.ToDecimal(value));

        private void OpenDialog(Payment payments)
        {

            var parameters = new DialogParameters();
            parameters.Add("PaymentModel", payments);
            parameters.Add("_parameters", _parameters);
            var options = new DialogOptions()
            {
                CloseOnEscapeKey = false,
                CloseButton = true,
                MaxWidth = MaxWidth.Large,
                Position = DialogPosition.TopCenter,
                DisableBackdropClick = true

            };

            DialogService.Show<EditPaymentDialog>("Edit Payment", parameters, options);

        }
        private void Addpayment()
        {
            var parameters = new DialogParameters();
            parameters.Add("EventId", EventId);
            var options = new DialogOptions()
            {
                CloseOnEscapeKey = false,
                CloseButton = true,
                MaxWidth = MaxWidth.Large,
                Position = DialogPosition.TopCenter,
                DisableBackdropClick = true

            };

            DialogService.Show<AddPaymentDialog>("Add Payment", parameters, options);

        }

        private List<BreadcrumbItem> _items = new List<BreadcrumbItem>
    {
        new BreadcrumbItem("Dashboard", href: "/dashboard", icon: Icons.Material.Filled.Home),
        new BreadcrumbItem("Event List", href:"/eventlist",  icon: Icons.Material.TwoTone.Event),
        new BreadcrumbItem("View Event", href: null, disabled: true, icon: Icons.Material.Filled.Create)
    };
    }
}
