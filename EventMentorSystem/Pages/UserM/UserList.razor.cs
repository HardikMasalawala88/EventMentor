using EMS.DB.Models;
using EMS.DB.Repository.Interface;
using EventMentorSystem.Data;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace EventMentorSystem.Pages.UserM
{
    public partial class UserList
    {
        [CascadingParameter(Name = "cascadeParameters")]
        public GlobalParameter _parameters { get; set; }
        [Inject] private IUserRepository _UserRepository { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        private List<User> userList = new();
        private User userModel = new();
        private string searchString = "";
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }

        private MudTable<User> tableRef;
        private IEnumerable<User> pagedData;
        private int totalItems;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                GetAllUsers();
            }

            return base.OnAfterRenderAsync(firstRender);
        }
        private void ShowHideAddForm() {
            IsAdd = !IsAdd;
        }
        private List<User> GetAllUsers()
        {
            userList = _UserRepository.GetAllUser();
            return userList;
        }

        private bool StringValid(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                return true;
            }

            return false;
        }

        private async Task<TableData<User>> ServerReload(TableState state)
        {
            IEnumerable<User> data;

            //get all data of current month
            data = _UserRepository.GetAllUser();

            data = data.Where(selectedModel => { return Search(selectedModel); }).ToArray();
            data = data.OrderByDirection(state.SortDirection, o => o.UserName);
            totalItems = data.Count();

            pagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();
            return new TableData<User>() { TotalItems = totalItems, Items = pagedData };
        }


        private bool Search(User Users)
        {
            if (string.IsNullOrEmpty(searchString) || !string.IsNullOrEmpty(searchString)
                && StringValid(Users.FullName)
                && StringValid(Users.Email)
                && StringValid(Users.Userrole)
                && StringValid(Users.ContactNo)
                &&
                 Users.FullName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || Users.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || Users.Userrole.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                || Users.ContactNo.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
        private void OnSearch(string text)
        {
            searchString = text;
            tableRef.ReloadServerData();
        }

        private void Edit(string id)
        {
            try
            {
                userModel = userList.FirstOrDefault(c => c.Id == id);
                IsEdit = true;
                tableRef.ReloadServerData();
            }
            catch (Exception ex)
            {
                _parameters.ShowErrorMessages(ex);
            }
        }
        private void Save()
        {
            try
            {
                _UserRepository.Update(userModel);
                IsEdit = false;
                tableRef.ReloadServerData();
            }
            catch (Exception ex)
            {
                _parameters.ShowErrorMessages(ex);
            }
        }
        private void Cancel()
        {
            userModel = new User();
            IsEdit = false;
        }
        //private async Task Delete(long id)
        //{
        //    try
        //    {
        //        _UserRepository.Delete(id);
        //        Snackbar.Add("Category Data Deleted.", Severity.Success);
        //        GetAllUser();
        //    }
        //    catch (Exception ex)
        //    {
        //        Snackbar.Add(ex.Message, Severity.Error);
        //    }
        //}

    }
}
