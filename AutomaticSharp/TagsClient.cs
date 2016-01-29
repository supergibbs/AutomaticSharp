using System.Collections.Generic;
using System.Threading.Tasks;
using AutomaticSharp.Models;
using AutomaticSharp.Requests;

namespace AutomaticSharp
{
    public partial class Client
    {
        /// <summary>
        /// Provides a listing of all tags on a user account
        /// </summary>
        /// <param name="request"><see cref="TagsRequest"/></param>
        /// <returns>List of Tags</returns>
        public async Task<List<Tag>> GetTagsAsync(TagsRequest request = null)
        {
            const string path = "tag/";

            if (request == null)
                return await GetAsync<List<Tag>>(path);

            return await GetAsync<List<Tag>>(path, request.CreateParameters());
        }
    }
}
