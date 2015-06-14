class CreateCons < ActiveRecord::Migration
  def change
    create_table :cons do |t|

      t.timestamps null: false
    end
  end
end
