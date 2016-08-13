using AutoMapper;

namespace Demo.Repository
{
    public static class ObjectMapper
    {
        public static TViewModel MapEntityToViewModel<TViewModel, TEntity>(TEntity entity)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TViewModel>());
            var mapper = config.CreateMapper();
            return mapper.Map<TViewModel>(entity);
        }

        public static TEntity MapViewModelToEntity<TEntity, TViewModel>(TViewModel vm)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TViewModel, TEntity>());
            var mapper = config.CreateMapper();
            return mapper.Map<TEntity>(vm);
        }
    }
}
