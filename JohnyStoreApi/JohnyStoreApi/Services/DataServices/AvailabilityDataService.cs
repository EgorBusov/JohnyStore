using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Models.Availability;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;
using JohnyStoreData.Models;

namespace JohnyStoreApi.Services.DataServices
{
    public class AvailabilityDataService : IAvailabilityDataService
    {
        private readonly JohnyStoreContext _context;
        private readonly IJohnyStoreLogger _logger;
        private readonly IConfiguration _configuration;

        public AvailabilityDataService(
            JohnyStoreContext context,
            IJohnyStoreLogger logger,
            IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        #region Availability CRUD

        /// <summary>
        /// Возращает запись о наличии определенной модели кроссовок
        /// </summary>
        /// <param name="idSneakerModel"></param>
        /// <returns></returns>
        public AvailabilityModel GetAvailability(int idSneakerModel)
        {
            return _context.Availability.First(x => x.IdModel == idSneakerModel || x.Visible == true)
                .MapToAvailabilityModel(_context, _configuration) ?? new AvailabilityModel();
        }

        /// <summary>
        /// Добавлениe наличия
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddAvailability(AvailabilityModel model)
        {
            try
            {
                if (model == null || model.Model == null || model.Model.Id == 0)
                    throw new Exception("При добавлении не указана модель");

                Availability availability = model.MapToAvailability();

                _context.Availability.Add(availability);

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// редактирование наличия
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditAvailability(AvailabilityModel model)
        {
            try
            {
                if (model == null || model.Model == null || model.Model.Id == 0)
                    throw new Exception("При редактировании не указана модель");

                Availability availability = model.MapToAvailability();
                Availability editAvailability = _context.Availability.First(x => x.Id == availability.Id && x.Visible == true)
                    ?? throw new Exception("Запись о наличии не найдена");

                editAvailability.IdModel = availability.Id;
                editAvailability.Status35 = availability.Status35;
                editAvailability.Status36 = availability.Status36;
                editAvailability.Status37 = availability.Status37;
                editAvailability.Status38 = availability.Status38;
                editAvailability.Status39 = availability.Status39;
                editAvailability.Status40 = availability.Status40;
                editAvailability.Status41 = availability.Status41;
                editAvailability.Status42 = availability.Status42;
                editAvailability.Status43 = availability.Status43;
                editAvailability.Status44 = availability.Status44;
                editAvailability.Status45 = availability.Status45;
                editAvailability.Status46 = availability.Status46;
                editAvailability.Visible = availability.Visible;

                return _context.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Удаляет запись о наличии
        /// </summary>
        /// <param name="availabilityId"></param>
        /// <returns></returns>
        public bool DeleteAvailability(int availabilityId)
        {
            try
            {
                Availability availability = _context.Availability.First(x => x.Id == availabilityId)
                    ?? throw new Exception("запись о наличии не найдена");
                availability.Visible = false;

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        #endregion

        #region Availability status CRD

        /// <summary>
        /// Получение всех возможных статусов наличия
        /// </summary>
        /// <returns></returns>
        public List<AvailabilityStatusModel> GetAvailabilityStatuses()
        {
            return _context.AvailabilityStatuses.Where(x => x.Visible == true).ToList().MapToAvailabilityStatusModel()
                ?? new List<AvailabilityStatusModel>();
        }

        /// <summary>
        /// Добавление статуса наличия
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddAvailabilityStatus(AvailabilityStatusModel model)
        {
            AvailabilityStatus status = model.MapToAvailabilityStatus();

            _context.AvailabilityStatuses.Add(status);
            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// Удаление статуса наличия
        /// </summary>
        /// <param name="availabilityId"></param>
        /// <returns></returns>
        public bool RemoveAvailabilityStatus(int availabilityId)
        {
            try
            {
                AvailabilityStatus status = _context.AvailabilityStatuses.First(x => x.Id == availabilityId)
                    ?? throw new Exception("запись о статусе не найдена");
                status.Visible = false;

                return _context.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
