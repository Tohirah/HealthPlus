using HealthPlus.Application.DTOs;
using HealthPlus.Domain.Enums;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IAppointmentService
    {
        BaseResponse BookAppointment(CreateAppointmentRequestModel request);
        public BaseResponse UpdateAppointment(int id, UpdateAppointmentRequestModel request);
        BaseResponse ApproveAppointment(int id);
        BaseResponse RejectAppointment(int id);
        BaseResponse CancelAppointment(int id);
        BaseResponse PayForAppointment(int id);
        BaseResponse AssignAppointmentToDoctor(int id, UpdateAppointmentRequestModel request);
        BaseResponse FulfillAppointment(int id);
        AppointmentResponseModel GetAppointmentById(int id);
        IList<AppointmentResponseModel> GetAppointments();
        IList<AppointmentResponseModel> GetAppointmentByPatientId(int id);

    }
}
