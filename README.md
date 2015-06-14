# Triviumer
Triviumer is a 3D web tool that is elaborating a classical methodology of learning, trivium.

## How to locally start it
1. Get all requirements
2. Turn neo4j on and check if it's on 7474 port by  connecting `localhost:7474`
3. Make a new file webapp/config/local_env.yml like below with your own neo4j administration account.

```
NEO4J_ID: '<your neo4j id>'
NEO4J_PASS: '<your neo4j password>'
```

4. Run below in webapp directory.

```
bundle install # acquire gems
rake db:migrate # DB migration
rails s # start the server. you can give -b 0.0.0.0 option to let the server run in public.
```

## Requirements
- Ruby 1.9.3p484 https://www.ruby-lang.org/
- Neo4j 2.3.0 http://neo4j.com/