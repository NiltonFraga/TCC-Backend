using Api.Domain.Request;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IPostRepo
    {
        Task<List<PostRes>> GetAllPost(PostFiltroReq filtroReq);
        Task<PostAndComentarioRes> GetPostAndComentarioById(int id);
        Task<PostRes> GetPostById(int id);
        Task PostPost(PostReq rq);
        Task UpdatePost(PostReq rq);
        Task DeletePost(int id);
    }
}
