class Pop
  include Neo4j::ActiveNode

  property :name
  property :X, type: Float
  property :Y, type: Float
  property :Z, type: Float

  has_many :both, :has, type: :pop, model_class: Pop

end