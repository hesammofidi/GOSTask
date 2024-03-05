using Application.Contract.Persistance.SystemsRolesManagment;
using Application.Dtos.CommonDtos;
using Application.Dtos.SystemRoleDtos;
using Application.Dtos.SystemsDto;
using Application.Models.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SystemRoleFeatures.Query
{
    public class SRQueryRequestsHandlers
    {
        #region Filter
        public class SRFilterQueryRequest : IRequest<PagedList<SystemRoleDto>>
        {
            public FilterDataDto? FilterDataDto { get; set; }
        }
        public class SRFilterQueryHandler : IRequestHandler<SRFilterQueryRequest, PagedList<SystemRoleDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolesRepository _systemRoleRepository;
            public SRFilterQueryHandler(IMapper mapper, ISystemsRolesRepository systemRoleRepository)
            {
                _mapper = mapper;
                _systemRoleRepository = systemRoleRepository;
            }
            public async Task<PagedList<SystemRoleDto>> Handle(SRFilterQueryRequest request, CancellationToken cancellationToken)
            {
                var filterdata = _mapper.Map<FilterData>(request.FilterDataDto);
                var systemRole = await _systemRoleRepository.FilterAsync(filterdata);
                var systemRoleItems = _mapper.Map<List<SystemRoleDto>>(systemRole.Items);
                return new PagedList<SystemRoleDto>
                    (
                    systemRoleItems, 
                    systemRole.Paging.PageSize, 
                    systemRole.Paging.CurrentPage,
                    systemRole.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region Serch
        public class SRSerchQueryRequest : IRequest<PagedList<SystemRoleDto>>
        {
            public SearchDataDto? SearchDataDto { get; set; }
        }
        public class SRSerchQueryHandler : IRequestHandler<SRSerchQueryRequest, PagedList<SystemRoleDto>>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolesRepository _systemRoleRepository;
            public SRSerchQueryHandler(IMapper mapper, ISystemsRolesRepository systemRoleRepository)
            {
                _mapper = mapper;
                _systemRoleRepository = systemRoleRepository;
            }
            public async Task<PagedList<SystemRoleDto>> Handle(SRSerchQueryRequest request, CancellationToken cancellationToken)
            {
                var searchdata = _mapper.Map<SearchData>(request.SearchDataDto);
                var systemRole = await _systemRoleRepository.SearchAsync(searchdata);
                var systemRoleItems = _mapper.Map<List<SystemRoleDto>>(systemRole.Items);
                return new PagedList<SystemRoleDto>
                    (
                    systemRoleItems,
                    systemRole.Paging.PageSize,
                    systemRole.Paging.CurrentPage,
                    systemRole.Paging.TotalRecordCount
                    );

            }
        }

        #endregion

        #region GetById
        public class GetSRRequestQuery : IRequest<SystemRoleDto>
        {
            public int SRId { get; set; }
        }
        public class GetSRHandlerQuery : IRequestHandler<GetSRRequestQuery, SystemRoleDto>
        {
            private readonly IMapper _mapper;
            private readonly ISystemsRolesRepository _systemRoleRepository;

            public GetSRHandlerQuery(ISystemsRolesRepository systemsRepository, IMapper mapper)
            {
                _systemRoleRepository = systemsRepository;
                _mapper = mapper;
            }

            public async Task<SystemRoleDto> Handle(GetSRRequestQuery request, CancellationToken cancellationToken)
            {
                var entity = await _systemRoleRepository.GetByIdAsync(request.SRId);
                var systemrle = _mapper.Map<SystemRoleDto>(entity);
                return systemrle;
            }
        }
        #endregion
    }
}
