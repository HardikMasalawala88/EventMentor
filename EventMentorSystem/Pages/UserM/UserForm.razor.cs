using EMS.DB.Constant;
using EMS.DB.Models;
using EMS.DB.Repository.Interface;
using EventMentorSystem.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMentorSystem.Pages.UserM
{
    public partial class UserForm
    {

        //private List<User> UserList = new();
        //private User userModel = new();
        //MudForm form;
        //public IList<AuthenticationScheme> ExternalLogins { get; set; }
        //protected override Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        //GetAllUser();
        //    }

        //    return base.OnAfterRenderAsync(firstRender);
        //}
        ////private List<User> GetAllUser()
        ////{
        ////    UserList = _UserRepository.GetUserList();
        ////    return UserList;
        ////}

        //private void Save()
        //{
        //    try
        //    {
        //        _UserRepository.Insert(userModel);
        //        Snackbar.Add(" record saved", Severity.Success);
        //        //GetAllUser();

        //        userModel = new User();
        //    }
        //    catch (Exception ex)
        //    {
        //        Snackbar.Add(ex.Message, Severity.Error);
        //    }
        //}
        //private void CancelForm()
        //{
        //    try
        //    {
        //        userModel = new User();
        //    }
        //    catch (Exception ex)
        //    {
        //        Snackbar.Add(ex.Message, Severity.Error);
        //    }
        //}

        [CascadingParameter(Name = "cascadeParameters")]
        public GlobalParameter _parameters { get; set; }
        [Inject] SignInManager<User> SignInManager { get; set; }
        [Inject] ISnackbar _snackbar { get; set; }
        [Inject] UserManager<User> UserManager { get; set; }


        [Parameter]
        public EventCallback  OnCancelEvent { get; set; }
        //[Inject] ILogger<UserForm> Logger { get; set; }
        //private readonly IEmailSender _emailSender;
        private User UserModel = new();
        private Operator OperatorModel = new();
        private Admin AdminModel = new();
        private Staff StaffModel = new();


        //public IList<AuthenticationScheme> ExternalLogins { get; set; }
 
        private void Cancel() {
            OnCancelEvent.InvokeAsync();
        }
        private async Task Save()
        {
                try
            {
                //ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                var user = new User
                {

                    FullName = UserModel.FullName,
                    UserName = UserModel.Email,
                    Email = UserModel.Email,
                    ContactNo = UserModel.ContactNo,
                    Userrole = UserModel.Userrole,
                    Useraddress = UserModel.Useraddress,
                };

                user.IsActive = true;
                var result = await UserManager.CreateAsync(user, UserModel.Password);

                if (result.Succeeded)
                {
                    //if (!string.IsNullOrWhiteSpace(UserModel.Userrole))
                    //{
                    //    var roles = UserModel.Userrole.Split(',').Select(a => a.Trim()).ToArray();
                    //    Console.WriteLine($"{roles.Length}");
                    //    foreach (var role in roles)
                    //    {
                    //        _ = UserManager.AddToRoleAsync(user, role).Result;
                    //    }
                    //}

                    if (UserModel.Userrole == Userrole.Operator.ToString())
                    {
                        OperatorModel.UserId = user.Id;
                        _OperatorRepository.Insert(OperatorModel);
                        //UserModel = new User();
                    }
                    else if (UserModel.Userrole == Userrole.Admin.ToString())
                    {
                        AdminModel.UserId = user.Id;
                        _AdminRepository.Insert(AdminModel);
                    }
                    else if (UserModel.Userrole == Userrole.Staff.ToString())
                    {
                        StaffModel.UserId = user.Id;
                        _StaffRepository.Insert(StaffModel);

                    }
                    if (!string.IsNullOrWhiteSpace(UserModel.Userrole))
                    {
                        var roles = UserModel.Userrole.Split(',').Select(a => a.Trim()).ToArray();
                        Console.WriteLine($"{roles.Length}");
                        foreach (var role in roles)
                        {
                            await UserManager.AddToRoleAsync(user, role);
                        }
                    }
                    UserModel = new User();

                    _snackbar.Add("Added successfully", Severity.Success);
                    StateHasChanged();
                }

                UserModel = new User();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
