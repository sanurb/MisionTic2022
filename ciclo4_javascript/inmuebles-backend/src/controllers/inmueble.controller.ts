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
import {Inmueble} from '../models';
import {InmuebleRepository} from '../repositories';

export class InmuebleController {
  constructor(
    @repository(InmuebleRepository)
    public inmuebleRepository : InmuebleRepository,
  ) {}

  @post('/inmueble')
  @response(200, {
    description: 'Inmueble model instance',
    content: {'application/json': {schema: getModelSchemaRef(Inmueble)}},
  })
  async create(
    @requestBody({
      content: {
        'application/json': {
          schema: getModelSchemaRef(Inmueble, {
            title: 'NewInmueble',
            exclude: ['_id'],
          }),
        },
      },
    })
    inmueble: Omit<Inmueble, '_id'>,
  ): Promise<Inmueble> {
    return this.inmuebleRepository.create(inmueble);
  }

  @get('/inmueble/count')
  @response(200, {
    description: 'Inmueble model count',
    content: {'application/json': {schema: CountSchema}},
  })
  async count(
    @param.where(Inmueble) where?: Where<Inmueble>,
  ): Promise<Count> {
    return this.inmuebleRepository.count(where);
  }

  @get('/inmueble')
  @response(200, {
    description: 'Array of Inmueble model instances',
    content: {
      'application/json': {
        schema: {
          type: 'array',
          items: getModelSchemaRef(Inmueble, {includeRelations: true}),
        },
      },
    },
  })
  async find(
    @param.filter(Inmueble) filter?: Filter<Inmueble>,
  ): Promise<Inmueble[]> {
    return this.inmuebleRepository.find(filter);
  }

  @patch('/inmueble')
  @response(200, {
    description: 'Inmueble PATCH success count',
    content: {'application/json': {schema: CountSchema}},
  })
  async updateAll(
    @requestBody({
      content: {
        'application/json': {
          schema: getModelSchemaRef(Inmueble, {partial: true}),
        },
      },
    })
    inmueble: Inmueble,
    @param.where(Inmueble) where?: Where<Inmueble>,
  ): Promise<Count> {
    return this.inmuebleRepository.updateAll(inmueble, where);
  }

  @get('/inmueble/{id}')
  @response(200, {
    description: 'Inmueble model instance',
    content: {
      'application/json': {
        schema: getModelSchemaRef(Inmueble, {includeRelations: true}),
      },
    },
  })
  async findById(
    @param.path.string('id') id: string,
    @param.filter(Inmueble, {exclude: 'where'}) filter?: FilterExcludingWhere<Inmueble>
  ): Promise<Inmueble> {
    return this.inmuebleRepository.findById(id, filter);
  }

  @patch('/inmueble/{id}')
  @response(204, {
    description: 'Inmueble PATCH success',
  })
  async updateById(
    @param.path.string('id') id: string,
    @requestBody({
      content: {
        'application/json': {
          schema: getModelSchemaRef(Inmueble, {partial: true}),
        },
      },
    })
    inmueble: Inmueble,
  ): Promise<void> {
    await this.inmuebleRepository.updateById(id, inmueble);
  }

  @put('/inmueble/{id}')
  @response(204, {
    description: 'Inmueble PUT success',
  })
  async replaceById(
    @param.path.string('id') id: string,
    @requestBody() inmueble: Inmueble,
  ): Promise<void> {
    await this.inmuebleRepository.replaceById(id, inmueble);
  }

  @del('/inmueble/{id}')
  @response(204, {
    description: 'Inmueble DELETE success',
  })
  async deleteById(@param.path.string('id') id: string): Promise<void> {
    await this.inmuebleRepository.deleteById(id);
  }
}
