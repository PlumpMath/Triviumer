json.array!(@users) do |user|
  json.extract! user, :id, :email, :nick, :pass_hash, :pass_salt
  json.url user_url(user, format: :json)
end
