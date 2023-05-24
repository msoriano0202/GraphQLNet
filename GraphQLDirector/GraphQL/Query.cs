using GraphQLDirector.Data;
using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Video> GetVideos([ScopedService] ApiDbContext context) 
        {
            return context.Videos!;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Director> GetDirectors([ScopedService] ApiDbContext context)
        {
            return context.Directores!;
        }
    }
}
