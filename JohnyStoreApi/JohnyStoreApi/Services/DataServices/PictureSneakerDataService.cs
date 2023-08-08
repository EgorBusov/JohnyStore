﻿using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Models.Picture;
using JohnyStoreApi.Services.Interfaces;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;
using JohnyStoreData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JohnyStoreApi.Services.Data
{
    public class PictureSneakerDataService : IPictureDataService
    {
        private readonly JohnyStoreContext _context;
        private readonly IConfiguration _configuration;
        private readonly IFileManager _fileManager;

        public PictureSneakerDataService(
            JohnyStoreContext context,
            IConfiguration configuration,
            IFileManager fileManager)
        {
            _context = context;
            _configuration = configuration;
            _fileManager = fileManager;
        }

        /// <summary>
        /// Получение картинки
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Stream GetPicture(string path)
        {
            var pathDirectory = _configuration.GetValue<string>("Paths:PathDirectoryPictureForSneaker");
            var fullPathDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathDirectory, path);

            return _fileManager.GetFile(fullPathDirectory);
        }

        /// <summary>
        /// Добавление картинок для кроссовок
        /// </summary>
        /// <param name="modelPictures"></param>
        /// <param name="idModel"></param>
        /// <returns></returns>
        public bool AddPictures(List<AddPictureSneakerModel> modelPictures, int idModel)
        {
            var pathDirectory = _configuration.GetValue<string>("Paths:PathDirectoryPictureForSneaker");
            var fullPathDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathDirectory);

            List<PictureSneaker> pictures = new List<PictureSneaker>();

            foreach (var picture in modelPictures)
            {
                PictureSneaker pictureSneaker = new PictureSneaker()
                {
                    IdModel = idModel,
                    Main = picture.Main,
                    Href = _fileManager.SaveFile(picture.File.OpenReadStream(), fullPathDirectory, Path.GetExtension(picture.File.FileName)),
                    Visible = true
                };

                pictures.Add(pictureSneaker);
            }

            _context.PictureSneakers.AddRange(pictures);
            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Удаление картинок относящихся к определенной модели кроссовок
        /// </summary>
        /// <param name="idModel"></param>
        /// <returns></returns>
        public bool DeletePictures(int idModel)
        {
            var pathDirectory = _configuration.GetValue<string>("Paths:PathDirectoryPictureForSneaker");
            var pictures = _context.PictureSneakers.Where(x => x.IdModel == idModel).ToList();

            foreach (var picture in pictures)
            {
                _fileManager.DeleteFile(pathDirectory + picture.Href);
            }

            _context.PictureSneakers.RemoveRange(pictures);
            _context.SaveChanges();

            return true;
        }
    }
}
