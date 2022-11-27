import {
  Count,
  CountSchema,
  Filter,
  FilterExcludingWhere,
  repository,
  Where,
} from '@loopback/repository';
import {
  post,
  param,
  get,
  getModelSchemaRef,
  patch,
  put,
  del,
  requestBody,
  response,
} from '@loopback/rest';
import {TipoInmueble} from '../models';
import {TipoInmuebleRepository} from '../repositories';

export class TipoInmuebleController {
  constructor(
    @repository(TipoInmuebleRepository)
    public tipoInmuebleRepository : TipoInmuebleRepository,
  ) {}

  @post('/tipo-inmueble')
  @response(200, {
    description: 'TipoInmueble model instance',
    content: {'application/json': {schema: getModelSchemaRef(TipoInmueble)}},
  })
  async create(
    @requestBody({
      content: {
        'application/json': {
          schema: getModelSchemaRef(TipoInmueble, {
            title: 'NewTipoInmueble',
            exclude: ['_id'],
          }),
        },
      },
    })
    tipoInmueble: Omit<TipoInmueble, '_id'>,
  ): Promise<TipoInmueble> {
    return this.tipoInmuebleRepository.create(tipoInmueble);
  }

  @get('/tipo-inmueble/count')
  @response(200, {
    description: 'TipoInmueble model count',
    content: {'application/json': {schema: CountSchema}},
  })
  async count(
    @param.where(TipoInmueble) where?: Where<TipoInmueble>,
  ): Promise<Count> {
    return this.tipoInmuebleRepository.count(where);
  }

  @get('/tipo-inmueble')
  @response(200, {
    description: 'Array of TipoInmueble model instances',
    content: {
      'application/json': {
        schema: {
          type: 'array',
          items: getModelSchemaRef(TipoInmueble, {includeRelations: true}),
        },
      },
    },
  })
  async find(
    @param.filter(TipoInmueble) filter?: Filter<TipoInmueble>,
  ): Promise<TipoInmueble[]> {
    return this.tipoInmuebleRepository.find(filter);
  }

  @patch('/tipo-inmueble')
  @response(200, {
    description: 'TipoInmueble PATCH success count',
    content: {'application/json': {schema: CountSchema}},
  })
  async updateAll(
    @requestBody({
      content: {
        'application/json': {
          schema: getModelSchemaRef(TipoInmueble, {partial: true}),
        },
      },
    })
    tipoInmueble: TipoInmueble,
    @param.where(TipoInmueble) where?: Where<TipoInmueble>,
  ): Promise<Count> {
    return this.tipoInmuebleRepository.updateAll(tipoInmueble, where);
  }

  @get('/tipo-inmueble/{id}')
  @response(200, {
    description: 'TipoInmueble model instance',
    content: {
      'application/json': {
        schema: getModelSchemaRef(TipoInmueble, {includeRelations: true}),
      },
    },
  })
  async findById(
    @param.path.string('id') id: string,
    @param.filter(TipoInmueble, {exclude: 'where'}) filter?: FilterExcludingWhere<TipoInmueble>
  ): Promise<TipoInmueble> {
    return this.tipoInmuebleRepository.findById(id, filter);
  }

  @patch('/tipo-inmueble/{id}')
  @response(204, {
    description: 'TipoInmueble PATCH success',
  })
  async updateById(
    @param.path.string('id') id: string,
    @requestBody({
      content: {
        'application/json': {
          schema: getModelSchemaRef(TipoInmueble, {partial: true}),
        },
      },
    })
    tipoInmueble: TipoInmueble,
  ): Promise<void> {
    await this.tipoInmuebleRepository.updateById(id, tipoInmueble);
  }

  @put('/tipo-inmueble/{id}')
  @response(204, {
    description: 'TipoInmueble PUT success',
  })
  async replaceById(
    @param.path.string('id') id: string,
    @requestBody() tipoInmueble: TipoInmueble,
  ): Promise<void> {
    await this.tipoInmuebleRepository.replaceById(id, tipoInmueble);
  }

  @del('/tipo-inmueble/{id}')
  @response(204, {
    description: 'TipoInmueble DELETE success',
  })
  async deleteById(@param.path.string('id') id: string): Promise<void> {
    await this.tipoInmuebleRepository.deleteById(id);
  }
}
