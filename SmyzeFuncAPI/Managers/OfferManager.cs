using SmyzeFuncAPI.Helpers;
using SmyzeFuncAPI.Models;
using System;
using System.IO;

namespace SmyzeFuncAPI.Managers
{
    public class OfferManager
    {
        public static string GetOffer(string path,string brand, string model, string offer)
        {
            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentNullException(nameof(brand));

            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrWhiteSpace(offer))
                throw new ArgumentNullException(nameof(offer));

            var car = GetCar(path + $"\\assets\\{brand.ToLower()}\\{brand.ToLower()}.yaml");
            car.Version = GetModel(path + $"\\assets\\{brand.ToLower()}\\{model.ToLower()}\\{model.ToLower()}.yaml");
            car.Offer = GetOffer(path + $"\\assets\\{brand.ToLower()}\\{model.ToLower()}\\{offer.ToLower()}.yaml");

            var response = ParserHelper.SerializeYaml<Car>(car);
            return response;
        }
        private static Car GetCar(string path)
        {
            var carText = File.ReadAllText(path);
            var car = ParserHelper.DesriazlizeYaml<Car>(carText);
            return car;
        }
        private static CarModel GetModel(string path)
        {
            var modeltext = File.ReadAllText(path);
            var model = ParserHelper.DesriazlizeYaml<CarModel>(modeltext);
            return model;
        }
        private static Offer GetOffer(string path)
        {
            var offerText = File.ReadAllText(path);
            var offer = ParserHelper.DesriazlizeYaml<Offer>(offerText);
            return offer;
        }
    }
}
