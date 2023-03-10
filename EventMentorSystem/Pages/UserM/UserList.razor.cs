using EMS.DB.Models;
using EMS.DB.Repository.Interface;
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

        [Inject] private IUserRepository _UserRepository { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        private List<User> userList = new();
        private User userModel = new();
        private string searchString = "";
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }

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

        private void Edit(string id)
        {
            try
            {
                userModel = userList.FirstOrDefault(c => c.Id == id);
                IsEdit = true;
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        private void Save()
        {
            try
            {
                _UserRepository.Update(userModel);
                IsEdit = false;
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
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
