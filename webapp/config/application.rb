require File.expand_path('../boot', __FILE__)

require 'rails/all'
require 'neo4j/railtie'

# Require the gems listed in Gemfile, including any gems
# you've limited to :test, :development, or :production.
Bundler.require(*Rails.groups)

module Triviumer
  class Application < Rails::Application
    # Settings in config/environments/* take precedence over those specified here.
    # Application configuration should go into files in config/initializers
    # -- all .rb files in that directory are automatically loaded.

    # Set Time.zone default to the specified zone and make Active Record auto-convert to this zone.
    # Run "rake -D time" for a list of tasks for finding time zone names. Default is UTC.
    # config.time_zone = 'Central Time (US & Canada)'

    # The default locale is :en and all translations from config/locales/*.rb,yml are auto loaded.
    # config.i18n.load_path += Dir[Rails.root.join('my', 'locales', '*.{rb,yml}').to_s]
    # config.i18n.default_locale = :de

    # Do not swallow errors in after_commit/after_rollback callbacks.
    config.active_record.raise_in_transactional_callbacks = true
    # config.jade.pretty = true
    # config.jade.compile_debug = true
    # config.jade.globals = ['helpers']
    config.web_console.whitelisted_ips = '10.0.2.2'

    config.generators { |g| g.orm :neo4j }
    config.neo4j.session_type :server_db
    config.neo4j.session_path = 'http://localhost:7474'
    config.neo4j.session_options = { basic_auth: { username: 'neo4j', password:'<your password here>'}}
  end
end