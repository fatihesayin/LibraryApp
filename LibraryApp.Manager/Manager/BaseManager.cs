using AutoMapper;
using LibraryApp.Utils;

namespace LibraryApp.Manager
{
    public class BaseManager
    {
        protected readonly IGuidGenerator _guidGenerator;
        protected readonly IMapper _mapper;
        public BaseManager(IGuidGenerator guidGenerator, IMapper mapper)
        {
            _guidGenerator = guidGenerator;
            _mapper = mapper;
        }
    }
}