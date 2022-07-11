using Desafio_Audaz.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Audaz.Repos
{
    class Repository
    {

        private List<IModel> _fakeDatabase = new List<IModel>();

        public void Insert(IModel model)
        {
            if (model.Id == Guid.Empty)
                throw new Exception("Não é possível salver um registro com Id não preenchido");

            var modelAlreadyExists = _fakeDatabase.Any(savedModel => savedModel.Id == model.Id);
            if (modelAlreadyExists)
                throw new Exception($"Já existe um registro para a entidade '{model.GetType().Name}' com o Id '{model.Id}'");

            _fakeDatabase.Add(model);
        }

        public void Update(IModel model)
        {
            var updatingModel = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == model.Id);
            if (updatingModel == null)
                throw new Exception($"Não há registros para a entidade '{model.GetType().Name}' com Id '{model.Id}'");

            _fakeDatabase.Remove(updatingModel);
            _fakeDatabase.Add(model);
        }

        public T GetById<T>(Guid id)
        {
            var model = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == id);
            return (T) Convert.ChangeType(model, typeof(T));
        }

        public List<T> GetAll<T>()
        {
            var allModels = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(T)));
            var convertedModels = allModels.Select(genericModel => Convert.ChangeType(genericModel, typeof(T))).ToList();
            var collection = convertedModels.ConvertAll(x => (T)x);

            return collection;
        }

    }
}
